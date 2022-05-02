using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace Jyankenpo
{
    [Activity(Label = "JogoMain")]
    public class JogoMain : Activity
    {
        ImageButton btnPedra, btnPapel, btnTesoura, btnCliqueJogador, btnApp;
        TextView txtMensagem, txtPlacarJogador, txtPlacarApp;
        int jogadorPontos, appPontos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.JogoLayout);

            DeclararObjetos();

            btnPedra.Click += BtnPedra_Click;
            btnPapel.Click += BtnPapel_Click;
            btnTesoura.Click += BtnTesoura_Click;
        }

        private void BtnTesoura_Click(object sender, EventArgs e)
        {
            btnCliqueJogador.SetImageResource(Resource.Drawable.hasami);
            EscolhaJogador(valorEscolhidoUsuario: "tesoura");
        }

        private void BtnPapel_Click(object sender, EventArgs e)
        {
            btnCliqueJogador.SetImageResource(Resource.Drawable.kami);
            EscolhaJogador(valorEscolhidoUsuario: "papel");
        }

        private void BtnPedra_Click(object sender, EventArgs e)
        {
            btnCliqueJogador.SetImageResource(Resource.Drawable.pedra);
            EscolhaJogador(valorEscolhidoUsuario: "pedra");
        }

        private void DeclararObjetos()
        {
            btnPedra = FindViewById<ImageButton>(Resource.Id.btnPedra);
            btnPapel = FindViewById<ImageButton>(Resource.Id.btnPapel);
            btnTesoura = FindViewById<ImageButton>(Resource.Id.btnTesoura);
            btnCliqueJogador = FindViewById<ImageButton>(Resource.Id.btnCliqueJogador);
            btnApp = FindViewById<ImageButton>(Resource.Id.btnAPP);
            txtMensagem = FindViewById<TextView>(Resource.Id.txtMensagem);
            txtPlacarJogador = FindViewById<TextView>(Resource.Id.txtPlacarJogador);
            txtPlacarApp = FindViewById<TextView>(Resource.Id.txtPlacarApp);
        }

        public void EscolhaJogador(string valorEscolhidoUsuario)
        {
            int numeroAleatorio = new Random().Next(3);
            string[] opcoes = { "pedra", "papel", "tesoura" };

            string opcoesApp = opcoes[numeroAleatorio];

            switch (opcoesApp) //fazer o app escolher a imagem aleatória
            {
                case "pedra":
                    btnApp.SetImageResource(Resource.Drawable.pedra);
                    break;
                case "papel":
                    btnApp.SetImageResource(Resource.Drawable.kami);
                    break;
                case "tesoura":
                    btnApp.SetImageResource(Resource.Drawable.hasami);
                    break;
            }

            if ((opcoesApp == "pedra" && valorEscolhidoUsuario == "tesoura") ||
                (opcoesApp == "papel" && valorEscolhidoUsuario == "pedra") ||
                (opcoesApp == "tesoura" && valorEscolhidoUsuario == "papel"))
            {
                txtMensagem.Text = "Você perdeu!";
                txtMensagem.SetTextColor(color: Color.Red);
                appPontos++; txtPlacarApp.Text = "" + appPontos.ToString();
            }
            else if ((valorEscolhidoUsuario == "pedra" && opcoesApp == "tesoura") ||
                (valorEscolhidoUsuario == "papel" && opcoesApp == "pedra") ||
                (valorEscolhidoUsuario == "tesoura" && opcoesApp == "papel"))
            {
                txtMensagem.Text = "Você ganhou!";
                txtMensagem.SetTextColor(color: Color.Blue);
                jogadorPontos++; txtPlacarJogador.Text = "" + jogadorPontos.ToString();
            }
            else
            {
                txtMensagem.Text = "Empatou";
                txtMensagem.SetTextColor(color: Color.Yellow);
            }
            if (jogadorPontos == 3)
            {
                txtMensagem.Text = "VOCÊ VENCEU MELHOR DE 3!";
                btnPedra.Enabled = false;
                btnPapel.Enabled = false;
                btnTesoura.Enabled = false;
            }
            else if (appPontos == 3)
            {
                txtMensagem.Text = "APP GANHOU MELHOR DE 3!";
                btnPedra.Enabled = false;
                btnPapel.Enabled = false;
                btnTesoura.Enabled = false;
            }
        }

    }
}