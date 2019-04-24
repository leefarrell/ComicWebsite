import { Component, OnInit } from '@angular/core';
import { Comic } from '../_models/comic';
import { ComicService } from '../_services/comic.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-comic-details',
  templateUrl: './comic-details.component.html',
  styleUrls: ['./comic-details.component.css']
})
export class ComicDetailsComponent implements OnInit {
  comic: Comic;
  confirmDelete = false;

  // public model: any;
  // public card: any;

  constructor(private comicService: ComicService, private alertify: AlertifyService, private route: ActivatedRoute
    , private router: Router, private authService: AuthService) {// this.resetModel();
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
/*
  resetModel(): any {
    this.model = {
      firstName: '',
      lastName: '',
      emailAddress: '',
      password: '',
      token: '',
    };
    this.card = { number: '', exp_month: '', exp_year: '', cvc: '' };
  }*/
  /*
  purchaseComic() {
    (<any>window).Stripe.card.createToken(
      this.card,
      (status: number, response: any) => {
        if (status === 200) {
          this.model.token = response.id;
          this.http
            .post('http://localhost:5000/api/comic/3', this.model)
            .subscribe(
              result => {
                this.resetModel();
                // this.successMessage = 'Thank you for purchasing a ticket!';
                // console.log(this.successMessage);
                this.changeDetector.detectChanges();
              },
              error => {
                this.alertify.error('There was a problem registering you.');
                // this.errorMessage = 'There was a problem registering you.';
                // console.error(error);
              }
            );
        } else {
          this.alertify.error('There was a problem purchasing the ticket.');
         // this.errorMessage = 'There was a problem purchasing the ticket.';
         // console.error(response.error.message);
        }
      }
    );
  }*/

}
