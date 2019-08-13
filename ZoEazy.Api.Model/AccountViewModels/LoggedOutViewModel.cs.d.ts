declare module server {
	interface loggedOutViewModel {
		postLogoutRedirectUri: string;
		clientName: string;
		signOutIframeUrl: string;
		automaticRedirectAfterSignOut: boolean;
		logoutId: string;
		triggerExternalSignout: boolean;
		externalAuthenticationScheme: string;
	}
}
