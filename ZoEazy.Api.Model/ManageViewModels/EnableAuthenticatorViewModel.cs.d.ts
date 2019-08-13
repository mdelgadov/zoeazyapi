declare module server {
	interface enableAuthenticatorViewModel {
		code: string;
		sharedKey: string;
		authenticatorUri: string;
	}
	interface generateRecoveryCodesViewModel {
		recoveryCodes: string[];
	}
}
