declare module server {
	interface registerViewModel {
		email: string;
		password: string;
		confirmPassword: string;
	}
	interface registerComplexViewModel {
		username: string;
		firstname: string;
		lastname: string;
		email: string;
		password: string;
		mobile: string;
	}
}
