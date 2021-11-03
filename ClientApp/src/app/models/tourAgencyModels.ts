export interface Country {
    id: number;
    name: string;
}

export interface Person {
    id: number;
    surname: string;
    name: string;
    patronymic: string;
    email: string;
    phone: string;
    sales: Sale[];
}

export interface Tour {
    id: number;
    name: string;
    price: number;
    departureTime: Date;
    departureCity: string;
    daysCount: number;
    nightsCount: number;
    hotel: Hotel;
    hotelId: number;
    sales: Sale[];
}

export interface Sale {
    id: number;
    saleTime: Date;
    count: number;
    person: Person;
    personId: number;

    tour: Tour;
    tourId: number;
}

export interface Hotel {
    id: number;
    name: string;
    type: string;
    description: string;
    country: Country;
    countryId: number;
    tours: Tour[];
}
