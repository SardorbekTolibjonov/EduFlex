﻿using EduFlex.Service.DTOs.Exams;

namespace EduFlex.Service.Interfaces.Exams;

public interface IExamService
{
    Task<ExamForResultDto> AddExamAsync(ExamForCreationDto dto);
    Task<bool> DeleteExamAsync(long id);
    Task<ExamForResultDto> UpdateExamAsync(long id, ExamForUpdateDto dto);
    Task<IEnumerable<ExamForResultDto>> GetExamsByGroupIdAsync(long groupId);
}