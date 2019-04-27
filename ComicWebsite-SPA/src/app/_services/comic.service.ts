import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comic } from '../_models/comic';
import { PageResults } from '../_models/paging';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ComicService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getComics(page?, comicsPerPage?, comicParameters?): Observable<PageResults<Comic[]>> {
    const pageResults: PageResults<Comic[]> = new PageResults<Comic[]>();
    let params = new HttpParams();

    if (page != null && comicsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', comicsPerPage);
    }

    if (comicParameters != null) {
      params = params.append('minDate', comicParameters.minDate);
      params = params.append('maxDate', comicParameters.maxDate);
    }

    return this.http.get<Comic[]>(this.baseUrl + 'comics', { observe: 'response', params}).pipe(
      map(response => {
        pageResults.results = response.body;
        if (response.headers.get('Pagination') != null) {
          pageResults.paging = JSON.parse(response.headers.get('Pagination'));
        }
        return pageResults;
      })
    );
  }

  getComicsH(): Observable<Comic[]> {
    return this.http.get<Comic[]>(this.baseUrl + 'comics');
  }

  getComic(id): Observable<Comic> {
    return this.http.get<Comic>(this.baseUrl + 'comics/' + id);
  }

  deleteComic(id): Observable<Comic> {
    return this.http.delete<Comic>(this.baseUrl + 'comics/' + id);
  }

  addComic(model: any) {
    return this.http.post(this.baseUrl + 'comics/addcomic', model);
  }


}
