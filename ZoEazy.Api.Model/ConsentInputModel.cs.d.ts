	interface consentInputModel {
		button: string;
		scopesConsented: string[];
		rememberConsent: boolean;
		returnUrl: {
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
	}
