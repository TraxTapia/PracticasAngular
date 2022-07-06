import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-listado-peliculas',
  templateUrl: './listado-peliculas.component.html',
  styleUrls: ['./listado-peliculas.component.css']
})
export class ListadoPeliculasComponent implements OnInit {

  constructor() { }
  @Input()    
  Peliculas;


  ngOnInit(): void {
    
    // setTimeout(() => {
    //   this.Peliculas =[{
    //     titulo:"Spider-Man",
    //     fechaLanzamiento:new Date('2021-12-15'),
    //     precio: 175.37
    //   },{
    //     titulo:"Cars-4",
    //     fechaLanzamiento:new Date('2021-12-15'),
    //     precio: 230.00
    //   },{
    //     titulo:"Moana",
    //     fechaLanzamiento:new Date('2021-12-15'),
    //     precio: 120.23
    //   }]
    // },500)
  }
remover(indicepelicula: number): void{
  this.Peliculas.splice(indicepelicula,1)

}
}
