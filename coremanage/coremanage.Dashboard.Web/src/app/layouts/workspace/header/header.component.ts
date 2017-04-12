import { Component } from '@angular/core';
import { Router } from '@angular/router';

// app
import { AuthService } from '../../../shared/services/auth/auth.service';

// styles
// import './header.component.scss';



@Component({
    selector: 'header-component',
    templateUrl: 'header.component.html',
    styleUrls: ['./header.component.scss']    
})

export class HeaderComponent {
    constructor(
        private authService: AuthService,
        private router: Router,
    ) { }

    ngOnInit() {        
    }
    public logout(): void {
        this.authService.logout();
        this.router.navigate(['login']);  
    }

     public reLogin(): void{      
        this.authService.refreshToken();        
    }
}
