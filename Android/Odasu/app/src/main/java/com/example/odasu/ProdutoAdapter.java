package com.example.odasu;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class ProdutoAdapter extends RecyclerView.Adapter<ProdutoAdapter.ProdutoViewHolder> {

    private final Context context;
    private List<Produto> listaProdutos;

    public ProdutoAdapter(Context context, List<Produto> listaProdutos) {
        this.context = context;
        this.listaProdutos = listaProdutos;
    }


    @NonNull
    @Override
    public ProdutoViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_produto, parent, false);
        return new ProdutoViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ProdutoViewHolder holder, int position) {
        Produto produto = listaProdutos.get(position);

        // Vinculando os dados com a UI
        holder.txtNomeProduto.setText(produto.getNome());
        holder.txtPrecoProduto.setText("R$ " + produto.getPreco());
        holder.txtLocalProduto.setText(produto.getLocal());

        // Se o produto tiver imagem(s), exibe a primeira imagem
        if (!produto.getImagens().isEmpty()) {
            byte[] imagemBytes = produto.getImagens().get(0);
            Bitmap imagemBitmap = BitmapFactory.decodeByteArray(imagemBytes, 0, imagemBytes.length);
            holder.imgVProduto.setImageBitmap(imagemBitmap);
        }
    }

    @Override
    public int getItemCount() {
        return listaProdutos.size();
    }

    public void atualizarProdutos(List<Produto> novosProdutos) {
        this.listaProdutos = novosProdutos;
        notifyDataSetChanged();
    }

    public static class ProdutoViewHolder extends RecyclerView.ViewHolder {

        ImageView imgVProduto;
        TextView txtNomeProduto;
        TextView txtPrecoProduto;
        TextView txtLocalProduto;

        public ProdutoViewHolder(View itemView) {
            super(itemView);
            imgVProduto = itemView.findViewById(R.id.imgVProduto);
            txtNomeProduto = itemView.findViewById(R.id.txtNomeProduto);
            txtPrecoProduto = itemView.findViewById(R.id.txtPrecoProduto);
            txtLocalProduto = itemView.findViewById(R.id.txtLocalProduto);
        }
    }
}
