﻿namespace DataPush.Domain.Commands;

public record CreateQuestionCommand(Guid UserId, string Message);