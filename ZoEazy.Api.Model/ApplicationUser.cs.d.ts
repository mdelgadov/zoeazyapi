	/** Add profile data for application users by adding properties to the ApplicationUser class */
	interface applicationUser extends identityUser {
		isEnabled: boolean;
		createdDate: Date;
		/** [StringLength(250)]public string FirstName { get; set; }[StringLength(250)]public string LastName { get; set; } */
		mobile: string;
		/** [NotMapped]public string Name{get{return this.FirstName + " " + this.LastName;}} */
		isAdmin: boolean;
		dataEventRecordsRole: string;
		securedFilesRole: string;
	}
