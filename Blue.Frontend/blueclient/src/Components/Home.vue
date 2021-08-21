<template>
    <div >
        <label  for="Nome">Nome</label>
        <InputText id="nome" type="text"  />
    </div>
    <br>
    <div class="p-m-2">
        <label for="fone">Telefone</label>
        <InputMask id="fone" mask="99999999999"  placeholder="99999999999"/>
    </div>
    <br>
    <div>
        <label for="Nome">Email</label>
        <InputText id="email" type="text" v-model="value2" />
    </div>
    <br>
    <Button label="Cadastrar" v-on:click="salvar()" />
    
    <div style="color: red">
        {{mensagem}}
    </div>
    <hr>
    <div class="card">
        <DataTable :value="Contatos" dataKey="id" responsiveLayout="scroll" :paginator="true" :rows="2" >
            <Column field="id" header="Id"></Column>
            <Column field="nome" header="Nome"></Column>
            <Column field="fone" header="Fone"></Column>
            <Column field="email" header="Email"></Column>
            <Column >
            <template  #body="slotProps">
                <Button  label="Editar" class="p-button-warning"  v-on:click="editar(slotProps.data)"/>
                <Button  label="Deletar" class="p-button-danger" v-on:click="deletar(slotProps.data.id)"/>
            </template>
            </Column>
        </DataTable>
    </div>    
</template>

<script>
import axios from 'axios';
export default {
        name: 'Home',
    
        data: () => {
            return {
                Contatos: [],
                contato: undefined,
                mensagem: "",
            }
         },
        methods:{
            lista(){
                axios.get(`https://localhost:5001/contatos`).then((res) => {
                this.Contatos = res.data    
                })
            },
            salvar(){
                if(this.contato){
                    this.alterar()
                    return
                }
                axios.post(`https://localhost:5001/api/Contato`, {
                    Nome: document.getElementById("nome").value,
                    Email: document.getElementById("email").value,
                    Fone: document.getElementById("fone").value
                }).then(() => {
                    this.lista()
                })
            },
            alterar(){
                this.contato.nome = document.getElementById("nome").value  
                this.contato.email = document.getElementById("email").value 
                this.contato.fone = document.getElementById("fone").value 

                axios.put(`https://localhost:5001/api/Contato/${this.contato.id}`, this.contato, {
                }).then(() => {
                    this.lista()
                    this.contato = undefined
                    document.getElementById("nome").value = ""
                    document.getElementById("email").value = ""
                    document.getElementById("fone").value = ""
                })
            },
            editar(contato){
                document.getElementById("nome").value = contato.nome
                document.getElementById("email").value = contato.email
                document.getElementById("fone").value = contato.fone
                this.contato = contato
                
            },
            deletar(id){
                if(confirm("Confirma a exclusão?")){
                    axios.delete(`https://localhost:5001/api/Contato/${id}`).then(()=>{
                        this.lista()
                    })
                }
            },
            exportCSV() {
            this.$refs.dt.exportCSV();
            }
        },

        created() {
            this.lista()
        }
}
</script>