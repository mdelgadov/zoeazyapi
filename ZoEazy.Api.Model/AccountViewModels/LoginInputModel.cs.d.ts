declare module server {
	interface loginInputModel {
		email: string;
		password: string;
		rememberLogin: boolean;
		returnUrl: string;
	}
}
