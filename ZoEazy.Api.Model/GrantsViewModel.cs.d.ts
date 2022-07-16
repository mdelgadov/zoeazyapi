	interface grantsViewModel {
		grants: any[];
	}
	interface grantViewModel {
		clientId: string;
		clientName: string;
		clientUrl: {
			absolutePath: string;
			absoluteUri: string;
			authority: string;
			dnsSafeHost: string;
			fragment: string;
			host: string;
			hostNameType: any;
			idnHost: string;
			isAbsoluteUri: boolean;
			isDefaultPort: boolean;
			isFile: boolean;
			isLoopback: boolean;
			isUnc: boolean;
			localPath: string;
			originalString: string;
			pathAndQuery: string;
			port: number;
			query: string;
			scheme: string;
			segments: string[];
			userEscaped: boolean;
			userInfo: string;
		};
		clientLogoUrl: {
			absolutePath: string;
			absoluteUri: string;
			authority: string;
			dnsSafeHost: string;
			fragment: string;
			host: string;
			hostNameType: any;
			idnHost: string;
			isAbsoluteUri: boolean;
			isDefaultPort: boolean;
			isFile: boolean;
			isLoopback: boolean;
			isUnc: boolean;
			localPath: string;
			originalString: string;
			pathAndQuery: string;
			port: number;
			query: string;
			scheme: string;
			segments: string[];
			userEscaped: boolean;
			userInfo: string;
		};
		created: Date;
		expires?: Date;
		identityGrantNames: string[];
		apiGrantNames: string[];
	}
