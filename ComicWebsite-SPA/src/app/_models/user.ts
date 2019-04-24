import { Photo } from './photo';

export interface User {
    id: number;
    username: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    interests?: string;
    photo?: Photo[];

}
