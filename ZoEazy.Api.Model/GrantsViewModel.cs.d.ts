declare module server {
	interface grantsViewModel {
		grants: server.grantViewModel[];
	}
	interface grantViewModel {
		clientId: string;
		clientName: string;
		clientUrl: string;
		clientLogoUrl: string;
		created: Date;
		expires?: Date;
		identityGrantNames: string[];
		apiGrantNames: string[];
	}
}
