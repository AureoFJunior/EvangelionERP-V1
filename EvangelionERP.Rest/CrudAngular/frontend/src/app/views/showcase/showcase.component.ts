import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-showcase',
  templateUrl: './showcase.component.html',
  styleUrls: ['./showcase.component.css']
})
export class ShowcaseComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  imgCollection: Array<object> = [
    {
      image: 'https://static.netshoes.com.br/produtos/camisa-polo-lacoste-super-light-masculina/14/770-1231-014/770-1231-014_zoom1.jpg?ts=1636537719&ims=544x',
      thumbImage: 'https://static.netshoes.com.br/produtos/camisa-polo-lacoste-super-light-masculina/14/770-1231-014/770-1231-014_zoom1.jpg?ts=1636537719&ims=544x',
      alt: 'Polo Lacoste Branca',
      title: 'Polo Lacoste Branca'
    }, {
      image: 'https://static.netshoes.com.br/produtos/camisa-polo-lacoste-sport-masculina/80/MSI-0169-080/MSI-0169-080_zoom1.jpg?ts=1597157845&ims=544x',
      thumbImage: 'https://static.netshoes.com.br/produtos/camisa-polo-lacoste-sport-masculina/80/MSI-0169-080/MSI-0169-080_zoom1.jpg?ts=1597157845&ims=544x',
      title: 'Polo Lacoste Azul e Branca',
      alt: 'Polo Lacoste Azul e Branca'
    }, {
      image: 'https://static.netshoes.com.br/produtos/polo-lacoste-slim-fit/06/D66-2254-006/D66-2254-006_zoom1.jpg?ts=1615421446',
      thumbImage: 'https://static.netshoes.com.br/produtos/polo-lacoste-slim-fit/06/D66-2254-006/D66-2254-006_zoom1.jpg?ts=1615421446',
      title: 'Polo Lacoste Preta',
      alt: 'Polo Lacoste Preta'
    }, {
      image: 'https://cdn.dooca.store/946/products/lx98rpxkrr3pzwq6bpmvbfut00r5caciqv6v_450x600+fill_ffffff.jpg?v=1617906014&webp=0',
      thumbImage: 'https://cdn.dooca.store/946/products/lx98rpxkrr3pzwq6bpmvbfut00r5caciqv6v_450x600+fill_ffffff.jpg?v=1617906014&webp=0',
      title: 'Polo Lacoste Vermelha',
      alt: 'Polo Lacoste Vermelha'
    }, {
      image: 'https://assets3.repassa.com.br/fit-in/480x0/filters:sharpen(0.5,0.5,true)/spree/products/2699988/original/IMG_0589.JPG',
      thumbImage: 'https://assets3.repassa.com.br/fit-in/480x0/filters:sharpen(0.5,0.5,true)/spree/products/2699988/original/IMG_0589.JPG',
      title: 'Polo Lacoste Azul',
      alt: 'Polo Lacoste Azul'
    }, {
    image: 'https://imgcentauro-a.akamaihd.net/1300x1300/96155505/camisa-polo-lacoste-chemise-masculina-img.jpg',
    thumbImage: 'https://imgcentauro-a.akamaihd.net/1300x1300/96155505/camisa-polo-lacoste-chemise-masculina-img.jpg',
    title: 'Polo Lacoste Azul Escuro',
    alt: 'Polo Lacoste Azul Escuro'
  }
];
  imgCollection2: Array<object> = [
    {
      image: 'https://cdn.awsli.com.br/600x450/293/293007/produto/104509147/f4db8df5e1.jpg',
      thumbImage: 'https://cdn.awsli.com.br/600x450/293/293007/produto/104509147/f4db8df5e1.jpg',
      alt: 'Camisa Flamengo',
      title: 'Camisa Flamengo'
    }, {
      image: 'https://i.pinimg.com/originals/5e/83/db/5e83dba5bac1507360c779c9a1242cb7.jpg',
      thumbImage: 'https://i.pinimg.com/originals/5e/83/db/5e83dba5bac1507360c779c9a1242cb7.jpg',
      title: 'Camisa do São Paulo',
      alt: 'Camisa do São Paulo'
    }, {
      image: 'https://cdn.awsli.com.br/600x450/1209/1209230/produto/78670944/912d91a208.jpg',
      thumbImage: 'https://cdn.awsli.com.br/600x450/1209/1209230/produto/78670944/912d91a208.jpg',
      title: 'Camisa do Santos',
      alt: 'Camisa do Santos'
    }, {
      image: 'https://mhmcdn.manualdohomemmoderno.com.br/?w=750&h=450&quality=31&clipping=landscape&url=https://manualdohomemmoderno.com.br/files/2021/07/11-camisas-mais-bonitas-de-times-brasileiros-em-2021-11-camisas-mais-bonitas-de-times-brasileiros-em-2021-3.jpg',
      thumbImage: 'https://mhmcdn.manualdohomemmoderno.com.br/?w=750&h=450&quality=31&clipping=landscape&url=https://manualdohomemmoderno.com.br/files/2021/07/11-camisas-mais-bonitas-de-times-brasileiros-em-2021-11-camisas-mais-bonitas-de-times-brasileiros-em-2021-3.jpg',
      title: 'Camisa Inter',
      alt: 'Camisa Inter'
    }, {
      image: 'https://static.shoptimao.com.br/produtos/camisa-corinthians-i-1819-sn-torcedor-nike-patch-campeao-brasileiro/28/HZM-0346-028/HZM-0346-028_zoom1.jpg?ts=1616689442',
      thumbImage: 'https://static.shoptimao.com.br/produtos/camisa-corinthians-i-1819-sn-torcedor-nike-patch-campeao-brasileiro/28/HZM-0346-028/HZM-0346-028_zoom1.jpg?ts=1616689442',
      title: 'Camisa Corinthians',
      alt: 'Camisa Corinthians'
    }, {
      image: 'http://d2r9epyceweg5n.cloudfront.net/stores/001/601/886/products/camisa-orgulho-lgbtqia-vasco-da-gama-2021-kappa-kano-cano-pride-brasileirao-brasileiro-campeonato-brasileiro1-a50c23c63d7f03057816270043095755-640-0.png',
      thumbImage: 'http://d2r9epyceweg5n.cloudfront.net/stores/001/601/886/products/camisa-orgulho-lgbtqia-vasco-da-gama-2021-kappa-kano-cano-pride-brasileirao-brasileiro-campeonato-brasileiro1-a50c23c63d7f03057816270043095755-640-0.png',
      title: 'Camisa Vasco',
      alt: 'Camisa Vasco'
    }
];
  imgCollection3: Array<object> = [
    {
      image: 'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-air-jordan-i-mid-unissex-554724-054-1.png',
      thumbImage: 'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-air-jordan-i-mid-unissex-554724-054-1.png',
      alt: 'Jordan Vermelho',
      title: 'Jordan Vermelho'
    }, {
      image: 'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-air-jordan-i-mid-unissex-554724-113-1.png',
      thumbImage: 'https://images.lojanike.com.br/1024x1024/produto/tenis-nike-air-jordan-i-mid-unissex-554724-113-1.png',
      title: 'Jordan Branco',
      alt: 'Jordan Branco'
    }, {
      image: 'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-140-1-11621539388.jpg',
      thumbImage: 'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-554724-140-1-11621539388.jpg',
      title: 'Jordan Azul',
      alt: 'Jordan Azul'
    }, {
      image: 'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-DC7294-103-1-11628869502.jpg',
      thumbImage: 'https://images.lojanike.com.br/1024x1024/produto/tenis-air-jordan-1-mid-DC7294-103-1-11628869502.jpg',
      title: 'Jordan Verde',
      alt: 'Jordan Verde'
    }, {
      image: 'https://static.lojanba.com/produtos/tenis-nike-nba-air-jordan-xxxii-masculino/02/D12-9383-002/D12-9383-002_zoom1.jpg?ts=1642670439',
      thumbImage: 'https://static.lojanba.com/produtos/tenis-nike-nba-air-jordan-xxxii-masculino/02/D12-9383-002/D12-9383-002_zoom1.jpg?ts=1642670439',
      title: 'Jordan Cinza',
      alt: 'Jordan Cinza'
    }, {
      image: 'https://d3ugyf2ht6aenh.cloudfront.net/stores/871/280/products/602637_01-jpg1-774e796ab2ce6516c215965034554911-1024-1024.jpeg',
      thumbImage: 'https://d3ugyf2ht6aenh.cloudfront.net/stores/871/280/products/602637_01-jpg1-774e796ab2ce6516c215965034554911-1024-1024.jpeg',
      title: 'Jordan Rosa',
      alt: 'Jordan Rosa'
    }
];

}