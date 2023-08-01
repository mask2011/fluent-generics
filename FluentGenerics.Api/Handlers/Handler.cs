namespace FluentGenerics.Api.Handlers;

public static class Handler
{
	public static class WithRequest<TReq>
	{
		public abstract class WithResponse<TRes>
		{
			public abstract Task<TRes> ExecuteAsync(
				TReq request,
				CancellationToken ct = default);
		}

		public abstract class WithoutResponse
		{
			public abstract Task ExecuteAsync(
				TReq request,
				CancellationToken ct = default);
		}
	}

	public static class WithoutRequest
	{
		public abstract class WithResponse<TRes>
		{
			public abstract Task<TRes> ExecuteAsync(CancellationToken ct = default);
		}

		public abstract class WithoutResponse
		{
			public abstract Task ExecuteAsync(CancellationToken ct = default);
		}
	}
}
