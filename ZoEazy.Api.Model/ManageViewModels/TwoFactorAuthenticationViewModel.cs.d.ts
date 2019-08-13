declare module server {
	interface twoFactorAuthenticationViewModel {
		hasAuthenticator: boolean;
		recoveryCodesLeft: number;
		is2faEnabled: boolean;
	}
}
