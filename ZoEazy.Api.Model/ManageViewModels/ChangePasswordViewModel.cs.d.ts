declare module server {
	interface changePasswordViewModel {
		oldPassword: string;
		newPassword: string;
		confirmPassword: string;
		statusMessage: string;
	}
}
