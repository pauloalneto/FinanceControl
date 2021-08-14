import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  menu: any = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.menu = [
      { icon: 'bi-bar-chart', route: '/', title: 'Dashboard'},
      {
        icon: 'bi-clipboard-data', route: '/', title: 'Reports', children:
          [
            {icon: '', route: '/', title: 'Invoice'}
          ]
      },
      { icon: 'bi-credit-card', route: '/', title: 'Cards' },
      { icon: 'bi-currency-dollar', route: '/', title: 'Invoices'},
      {
        icon: 'bi-gear', route: '/', title: 'Settings', children:
          [
            { icon: '', route: '/flag', title: 'Flags' },
            { icon: '', route: '/', title: 'Invoice Status' },
          ]
      },
    ]

    this.router.events
      .pipe(
        // Filter the NavigationEnd events as the breadcrumb is updated only when the route reaches its end 
        filter((event) => event instanceof NavigationEnd)
      )
      .subscribe((event) => {
        // Construct the breadcrumb hierarchy 
        const root = this.router.routerState.snapshot.root;
        console.log(root)
      });

  }

  openSideNav(event: any) {
    console.log('testeclick ', event)
  }


}
