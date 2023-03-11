﻿using System.ComponentModel.DataAnnotations;
using static EmployeeSystem.Core.ModelsConstants.Task;

namespace EmployeeSystem.Core.Tasks.Models;

public class TaskInputModel
{
	[Required(ErrorMessage = TITLE_REQUIRED)]
	[MinLength(TITLE_DESCRIPTION_MIN_LENGTH, ErrorMessage = $"{{0}} {TITLE_DESCRIPTION_MIN_LENGTH_ERRORR}")]
	public required string Title { get; init; }

	[Required(ErrorMessage = DESCRIPTION_REQUIRED)]
	[MinLength(TITLE_DESCRIPTION_MIN_LENGTH, ErrorMessage = $"{{0}} {TITLE_DESCRIPTION_MIN_LENGTH_ERRORR}")]
	public required string Description { get; init; }

	[Required(ErrorMessage = DUEDATE_REQUIRED)]
	[DataType(DataType.Date, ErrorMessage = "Invalid date.")]
	[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
	public required DateTime DueDate { get; init; }

	[Required]
    public required int AssigneeId { get; init; }
}
