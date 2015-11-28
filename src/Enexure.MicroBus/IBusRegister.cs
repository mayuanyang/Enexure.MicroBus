using System;
using System.Collections.Generic;
using System.Reflection;

namespace Enexure.MicroBus
{
	public interface IHandlerRegister
	{
		ICommandBuilder<TCommand> RegisterCommand<TCommand>()
			where TCommand : ICommand;

		ICommandBuilder RegisterCommand(Type type);

		IEventBuilder<TEvent> RegisterEvent<TEvent>()
			where TEvent : IEvent;

		IEventBuilder RegisterEvent(Type type);

		IQueryBuilder<TQuery, TResult> RegisterQuery<TQuery, TResult>()
			where TQuery : IQuery<TQuery, TResult>
			where TResult : IResult;

		IQueryBuilder RegisterQuery(Type type);

		IHandlerRegister RegisterMessage(MessageRegistration messageRegistration);


		IReadOnlyCollection<MessageRegistration> GetMessageRegistrations();

		IHandlerRegister RegisterTypes(params Assembly[] assemblies);

		IHandlerRegister RegisterTypes(Func<Type, bool> predicate, params Assembly[] assemblies);

		IHandlerRegister RegisterTypes(Pipeline pipeline, params Assembly[] assemblies);

		IHandlerRegister RegisterTypes(Func<Type, bool> predicate, Pipeline pipeline, params Assembly[] assemblies);
	}
}