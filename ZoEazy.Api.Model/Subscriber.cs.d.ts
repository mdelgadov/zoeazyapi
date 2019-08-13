declare module server {
	interface subscriber extends applicationUser {
		/** public string FirstName { get; set; } */
		middleName: string;
		/** public string LastName { get; set; } */
		image: any[];
		imageSource: string;
		gender: any;
		website: string;
		paymentSystemId: string;
		l4DSSN: string;
		dateOfBirth: {
			day: number;
			month: number;
			year: number;
		};
		suspended: {
			value: boolean;
		};
		phones: any[];
		fax: {
			id: number;
			number: string;
			subscriber_Id: any;
		/** public string Locale { get; set; } */
			deleted: boolean;
		};
		address: {
			subscriber_Id: any;
			street: string;
			apartment: string;
			city: string;
			postalCode: string;
			latitude: number;
			longitude: number;
		/** [TsIgnore]public DbGeography Position { get; set; } */
			state_Id?: number;
		};
		creditCards: any[];
		franchises: any[];
	}
}
