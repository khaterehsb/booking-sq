declare module server {
	interface bookingDto {
		id: number;
		name: string;
		createdAt: Date;
		status: any;
		startDate?: Date;
		price: number;
		currency: string;
		leaders: any[];
	}
}
