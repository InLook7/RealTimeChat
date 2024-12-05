using FluentResults;
using MediatR;

namespace RealTimeChat.Application.Features.Sentiments.Create;

public record CreateSentimentCommand(
    int MessageId,
    string Content) : IRequest<Result<string>>;