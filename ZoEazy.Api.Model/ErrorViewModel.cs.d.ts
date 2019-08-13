declare module server {
	interface errorViewModel {
		error: {
			displayMode: string;
			uiLocales: string;
			error: string;
			errorDescription: string;
			requestId: string;
			redirectUri: string;
			responseMode: string;
		};
	}
}
