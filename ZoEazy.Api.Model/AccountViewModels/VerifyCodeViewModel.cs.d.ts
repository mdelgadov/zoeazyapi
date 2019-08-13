declare module server {
	interface verifyCodeViewModel {
		provider: string;
		code: string;
		returnUrl: string;
		rememberBrowser: boolean;
		rememberMe: boolean;
	}
	interface verifyComplexCodeViewModel {
		provider: string;
		code: string;
		returnUrl: string;
		rememberBrowser: boolean;
		rememberMe: boolean;
	}
}
