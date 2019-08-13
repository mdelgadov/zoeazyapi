declare module server {
	interface loginComplexViewMOdel extends loginInputModel {
		allowRememberLogin: boolean;
		enableLocalLogin: boolean;
		externalProviders: server.externalProvider[];
		visibleExternalProviders: server.externalProvider[];
		isExternalLoginOnly: boolean;
		externalLoginScheme: string;
	}
	interface loginViewModel {
		email: string;
		password: string;
		rememberMe: boolean;
	}
}
