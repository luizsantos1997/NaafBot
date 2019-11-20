new Vue({
    el: "#app",
    data: {
      talks:[
      {text:'Olá Seja Bem vindo!',
      isBotAnswer:true}
      ],
      newText:''
    },
    methods: {
    
    AddText(){
    if(this.newText === '' || 
         this.newText === null){
       alert("Texto vazio!");
       return false;
       }
      var newTalk = {text:this.newText,
      isBotAnswer:false};
        this.talks.push(newTalk);
      this.newText = '';
    }
      
    }
  });
