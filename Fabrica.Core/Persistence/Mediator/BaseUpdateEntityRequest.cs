﻿using Fabrica.Models;
using MediatR;

namespace Fabrica.Persistence.Mediator;

public abstract record BaseUpdateEntityRequest<TDelta>( string Uid, TDelta Delta ) : IRequest<Response> where TDelta : BaseDelta;