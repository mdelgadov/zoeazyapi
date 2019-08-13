declare module server {
	interface consentViewModel extends consentInputModel {
		clientName: string;
		clientUrl: string;
		clientLogoUrl: string;
		allowRememberConsent: boolean;
		identityScopes: server.scopeViewModel[];
		resourceScopes: server.scopeViewModel[];
	}
	interface scopeViewModel {
		name: string;
		displayName: string;
		description: string;
		emphasize: boolean;
		required: boolean;
		checked: boolean;
	}
}
