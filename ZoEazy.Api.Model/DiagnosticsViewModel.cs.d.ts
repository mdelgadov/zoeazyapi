declare module server {
	interface diagnosticsViewModel {
		authenticateResult: {
			succeeded: boolean;
			ticket: {
				authenticationScheme: string;
				principal: {
					claims: any[];
					identities: any[];
					identity: any;
				};
				properties: {
					items: any[];
					parameters: any[];
					isPersistent: boolean;
					redirectUri: string;
					issuedUtc?: Date;
					expiresUtc?: Date;
					allowRefresh?: boolean;
				};
			};
			principal: {
				claims: any[];
				identities: any[];
				identity: any;
			};
			properties: {
				items: any[];
				parameters: any[];
				isPersistent: boolean;
				redirectUri: string;
				issuedUtc?: Date;
				expiresUtc?: Date;
				allowRefresh?: boolean;
			};
			failure: {
				data: any[];
				helpLink: string;
				hResult: number;
				innerException: any;
				message: string;
				source: string;
				stackTrace: string;
				targetSite: {
					attributes: any;
					callingConvention: any;
					containsGenericParameters: boolean;
					isAbstract: boolean;
					isAssembly: boolean;
					isConstructedGenericMethod: boolean;
					isConstructor: boolean;
					isFamily: boolean;
					isFamilyAndAssembly: boolean;
					isFamilyOrAssembly: boolean;
					isFinal: boolean;
					isGenericMethod: boolean;
					isGenericMethodDefinition: boolean;
					isHideBySig: boolean;
					isPrivate: boolean;
					isPublic: boolean;
					isSecurityCritical: boolean;
					isSecuritySafeCritical: boolean;
					isSecurityTransparent: boolean;
					isSpecialName: boolean;
					isStatic: boolean;
					isVirtual: boolean;
					methodHandle: any;
					methodImplementationFlags: any;
				};
			};
			none: boolean;
		};
		clients: string[];
	}
}
