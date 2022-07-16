	interface subscriber extends applicationUser {
		name: {
			first: string;
			middle: string;
			last: string;
			middleInitial: string;
			full: string;
			fullWithMiddleInitial: string;
			fullWithMiddleName: string;
			fullLastFirst: string;
			fullLastFirstWithMiddleInitial: string;
			fullLastFirstWithMiddleName: string;
		};
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
			subscriberId: any;
		};
		address: {
			subscriberId: any;
		};
		creditCards: any[];
		franchises: any[];
		created: {
			byUser: any;
		};
		updated: {
			byUser: any;
		};
		deleted: {
			byUser: any;
		};
	}
