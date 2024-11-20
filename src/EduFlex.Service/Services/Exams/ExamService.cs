using AutoMapper;
using EduFlex.Data.IRepositories;
using EduFlex.Domain.Entities.Exams;
using EduFlex.Domain.Entities.Groups;
using EduFlex.Domain.Entities.Users;
using EduFlex.Domain.Enums;
using EduFlex.Service.DTOs.Exams;
using EduFlex.Service.Exceptions;
using EduFlex.Service.Interfaces.Exams;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace EduFlex.Service.Services.Exams;

public class ExamService : IExamService
{
    private readonly IMapper mapper;
    private readonly IRepositoryBase<Exam> examRepository;
    private readonly IRepositoryBase<User> userRepository;
    private readonly IRepositoryBase<Group> groupRepository;

    public ExamService(IMapper mapper, 
        IRepositoryBase<Exam> examRepository, 
        IRepositoryBase<User> userRepository, 
        IRepositoryBase<Group> groupRepository)
    {
        this.mapper = mapper;
        this.examRepository = examRepository;
        this.userRepository = userRepository;
        this.groupRepository = groupRepository;
    }
    public async Task<ExamForResultDto> AddExamAsync(ExamForCreationDto dto)
    {
        var user = await this.userRepository.GetAllAsync()
                                            .Where(u => u.Id == dto.StudentId)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404,"User not found");

        var group = await this.groupRepository.GetAllAsync()
                                              .Where(g => g.Id == dto.GroupId)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();
        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var date = DateTime.ParseExact(dto.ExamDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        var exam = await this.examRepository.GetAllAsync()
                                            .Where(e => e.ExamDate == date && 
                                            e.GroupId == dto.GroupId && 
                                            e.StudentId == dto.StudentId)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

        if (exam != null)
            throw new EduFlexException(400, "Exam already exists");
        if(dto.ExamResult < 0)
            throw new EduFlexException(400, "Invalid exam result");

        if(dto.ExamResult >= 60)
            exam.Status = ExamStatus.passed;
        else
            exam.Status = ExamStatus.failed;

        var entity = this.mapper.Map<Exam>(dto);
        entity.ExamDate = date;

        var result = await this.examRepository.AddAsync(entity);

        return this.mapper.Map<ExamForResultDto>(result);
    }

    public async Task<bool> DeleteExamAsync(long id)
    {
        var exam = await this.examRepository.GetAllAsync()
                                            .Where(e => e.Id == id)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

        if (exam == null)
            throw new EduFlexException(404, "Exam not found");

        return await this.examRepository.RemoveAsync(id);
    }

    public async Task<IEnumerable<ExamForResultDto>> GetExamsByGroupIdAsync(long groupId)
    {
        var exams = await this.examRepository.GetAllAsync()
                                             .Where(e => e.GroupId == groupId)
                                             .AsNoTracking()
                                             .ToListAsync();

        if (exams == null)
            throw new EduFlexException(404, "Exams not found");

        return this.mapper.Map<IEnumerable<ExamForResultDto>>(exams);
    }

    public async Task<ExamForResultDto> UpdateExamAsync(long id, ExamForUpdateDto dto)
    {
        var user = await this.userRepository.GetAllAsync()
                                            .Where(u => u.Id == dto.StudentId)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();

        if (user == null)
            throw new EduFlexException(404, "User not found");

        var group = await this.groupRepository.GetAllAsync()
                                              .Where(g => g.Id == dto.GroupId)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();
        if (group == null)
            throw new EduFlexException(404, "Group not found");

        var exam = await this.examRepository.GetAllAsync()
                                            .Where(e => e.Id == id)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();
        if (exam == null)
            throw new EduFlexException(404, "Exam not found");

        if (dto.ExamResult < 0)
            throw new EduFlexException(400, "Invalid exam result");

        if (dto.ExamResult >= 60)
            exam.Status = ExamStatus.passed;
        else
            exam.Status = ExamStatus.failed;

        var date = DateTime.ParseExact(dto.ExamDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        var entity = this.mapper.Map(dto,exam);
        entity.ExamDate = date;
        entity.UpdatedAt = DateTime.UtcNow;

        var result = await this.examRepository.UpdateAsync(entity);

        return this.mapper.Map<ExamForResultDto>(result);
    }
}
