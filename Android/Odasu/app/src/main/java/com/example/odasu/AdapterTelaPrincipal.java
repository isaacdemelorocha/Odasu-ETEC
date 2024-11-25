package com.example.odasu;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class AdapterTelaPrincipal extends RecyclerView.Adapter<AdapterTelaPrincipal.ViewHolder> {

    List<String> titulos;
    List <Integer> imagens;
    LayoutInflater inflater;
    Context context;
    private ViewGroup parent;

    public AdapterTelaPrincipal(Context ctx, List<String>titulo, List<Integer>imagem){
        this.titulos = titulo;
        this.imagens = imagem;
        this.inflater = LayoutInflater.from(ctx);
        this.context = ctx;
    }

    @NonNull
    @Override
    public AdapterTelaPrincipal.ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View view = inflater.inflate(R.layout.custom_layout_tela_principal,parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull AdapterTelaPrincipal.ViewHolder viewHolder, int i) {

        viewHolder.titulo.setText(titulos.get(i));
        viewHolder.imagemIcon.setImageResource(imagens.get(i));

        // Adiciona o listener de clique
        viewHolder.itemView.setOnClickListener(v -> {
            Intent intent = new Intent(context, ListaProdutos.class);
            context.startActivity(intent); // Inicia a nova Activity
        });

    }

    @Override
    public int getItemCount() {
        return titulos.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {

        TextView titulo;
        ImageView imagemIcon;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            titulo = itemView.findViewById(R.id.txtNome);
            imagemIcon = itemView.findViewById(R.id.imgIcone);
        }

    }
}
