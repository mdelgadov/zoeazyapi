declare module server {
	interface consentInputModel {
		button: string;
		scopesConsented: string[];
		rememberConsent: boolean;
		returnUrl: string;
	}
}
