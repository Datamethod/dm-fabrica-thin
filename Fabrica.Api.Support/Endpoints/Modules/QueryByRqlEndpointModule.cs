﻿
// ReSharper disable StaticMemberInGenericType

using Fabrica.Api.Endpoints.Requests;
using Fabrica.Endpoints;
using Fabrica.Exceptions;
using Fabrica.Mediator;
using Fabrica.Persistence;
using Fabrica.Utilities.Container;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Fabrica.Api.Endpoints.Modules;

public abstract class QueryByRqlEndpointModule<TEntity>( ICorrelation correlation, IRequestMediator mediator ): BaseManyDispatchEndpointModule<QueryByRqlEntityRequest<TEntity>,TEntity>(correlation,mediator), IEndpointModule where TEntity : class, IEntity
{

    public void AddRoutes(IEndpointRouteBuilder builder)
    {

        var route = GetRoute();

        builder.MapGet( route, async ([AsParameters] QueryByRqlEntityRequest<TEntity> request ) => await Handle( request ) )
            .WithTags(Plural)
            .WithSummary($"Query {Name}")
            .WithDescription($"Query {Name} using RQL")
            .Produces<List<TEntity>>()
            .Produces<ProblemDetail>(400, "application/problem+json")
            .Produces<ProblemDetail>(422, "application/problem+json")
            .WithOpenApi();

    }


}
