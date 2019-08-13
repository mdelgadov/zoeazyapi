declare module server {
	/** Add profile data for application users by adding properties to the ApplicationUser class */
	interface applicationUser extends identityUser {
		isEnabled: boolean;
		createdDate: Date;
		firstName: string;
		lastName: string;
		mobile: string;
		name: string;
		isAdmin: boolean;
		dataEventRecordsRole: string;
		securedFilesRole: string;
	}
}
