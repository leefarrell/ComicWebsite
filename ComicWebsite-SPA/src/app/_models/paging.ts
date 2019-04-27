export interface Paging {
    currentPage: number;
    comicsPerPage: number;
    totalComics: number;
    totalPages: number;
}

export class PageResults<Comic> {
    results: Comic;
    paging: Paging;
}
