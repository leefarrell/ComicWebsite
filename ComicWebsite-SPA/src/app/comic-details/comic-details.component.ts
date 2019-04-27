import { Component, OnInit } from '@angular/core';
import { Comic } from '../_models/comic';
import { ComicService } from '../_services/comic.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Headers, RequestOptions } from '@angular/http';

@Component({
  selector: 'app-comic-details',
  templateUrl: './comic-details.component.html',
  styleUrls: ['./comic-details.component.css']
})
export class ComicDetailsComponent implements OnInit {
  comic: Comic;
  confirmDelete = false;
  private _options = { headers: new HttpHeaders({'content-type': 'application/json'})};
  // public model: any;
  // public card: any;
  takePaymentResult: string;

  constructor(private comicService: ComicService, private alertify: AlertifyService, private route: ActivatedRoute
    , private router: Router, private authService: AuthService, private http: HttpClient) {// this.resetModel();
    }


  ngOnInit() {
    this.loadComic();
  }

  loadComic() {
    this.comicService.getComic(this.route.snapshot.params['id']).subscribe((comic: Comic) => {
      this.comic = comic;
    }, error => {
      this.alertify.error(error);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  removeComic() {
    this.comicService.deleteComic(this.route.snapshot.params['id']).subscribe((comic: Comic) => {
      this.comic = comic;
    }, error => {
      this.alertify.error(error);
       }, () => {
      this.router.navigate(['/comics']);
    });
  }

  takePayment(productName: string, amount: number, token: any) {
    const body = {
        tokenId: token.id,
        productName: productName,
        amount: amount
    };
    const bodyString = JSON.stringify(body);
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });
    this.http.post('http://localhost:5000/api/stripepayment/payment', bodyString, this._options)
        .toPromise()
        .then((res) => {
          console.log('success');
          this.alertify.success('Purchase successful');
            this.takePaymentResult = 'success';
        })
        .catch((error) => {
            this.takePaymentResult = error.message;
            this.alertify.success('Purchase successful');
        });

}

openCheckout(productName: string, amount: number, tokenCallback) {
    const handler = (<any>window).StripeCheckout.configure({
        key: 'pk_test_JW5ncLtXvbJueeIDyy5aIrGL00AW8Id8Ld',
        locale: 'auto',
        token: tokenCallback
    });

    handler.open({
        name: 'Purchase Comic',
        description: productName,
        zipCode: false,
        currency: 'eur',
        amount: amount,
        panelLabel: 'Pay {{amount}}',
        allowRememberMe: false
    });
}

buyComic(name) {
  this.openCheckout(name , 399, (token: any) => this.takePayment(name, 399, token));
}

}
