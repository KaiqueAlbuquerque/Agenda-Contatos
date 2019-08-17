export default class AgendaService{
    constructor(url = 'http://localhost:55324/api/Contato'){
        this._url = url;
    }

    get(){
        return fetch(this._url, 
            {
                headers: {'Content-type' : 'application/json'}
            })
            .then(res => {
                if(res.status == 200)
                {
                  return res.json();
                }
            })  
        
    }

    getById(idContato){
        return fetch(`${this._url}?idContato=${idContato}`,
            {
                headers: {'Content-type' : 'application/json'}
            })
            .then(res => {
                if(res.status == 200)
                {
                  return res.json();
                }
            }) 
    }

    post(contato){
        return fetch(this._url,
            {
                headers: {'Content-type' : 'application/json'},
                method: 'post',
                body: JSON.stringify(contato)
            })
            .then(res => {
                if(res.status == 200)
                {
                  return "Contato cadastrado com sucesso";
                }
            })
    }

    put(contato){
        return fetch(this._url,
            {
                headers: {'Content-type' : 'application/json'},
                method: 'put',
                body: JSON.stringify(contato)
            })
            .then(res => {
                if(res.status == 200)
                {
                  return "Contato alterado com sucesso";
                }
            })
    }

    delete(id){
        return fetch(`${this._url}?idContato=${id}` , 
            {
                headers: {'Content-type' : 'application/json'},
                method: 'delete'
            })
    }
}