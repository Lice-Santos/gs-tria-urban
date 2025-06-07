using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gs_tria_2025.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Itens_ItemId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_PontosDistribuicao_PontoDistribuicaoId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosDistribuicao_Enderecos_EnderecoId",
                table: "PontosDistribuicao");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosDistribuicao_Usuarios_UsuarioId",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_PontosDistribuicao_EnderecoId",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_PontosDistribuicao_UsuarioId",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_ItemId",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_PontoDistribuicaoId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "PontosDistribuicao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "PontosDistribuicao");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Estoques");

            migrationBuilder.DropColumn(
                name: "PontoDistribuicaoId",
                table: "Estoques");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuarios",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Usuarios",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PontosDistribuicao",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Itens",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Enderecos",
                type: "NVARCHAR2(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "NVARCHAR2(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "NVARCHAR2(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "NVARCHAR2(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_PontosDistribuicao_IdEndereco",
                table: "PontosDistribuicao",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_PontosDistribuicao_IdUsuario",
                table: "PontosDistribuicao",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_IdItem",
                table: "Estoques",
                column: "IdItem");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_IdPontoDistribuicao",
                table: "Estoques",
                column: "IdPontoDistribuicao");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Itens_IdItem",
                table: "Estoques",
                column: "IdItem",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_PontosDistribuicao_IdPontoDistribuicao",
                table: "Estoques",
                column: "IdPontoDistribuicao",
                principalTable: "PontosDistribuicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDistribuicao_Enderecos_IdEndereco",
                table: "PontosDistribuicao",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDistribuicao_Usuarios_IdUsuario",
                table: "PontosDistribuicao",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Itens_IdItem",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_PontosDistribuicao_IdPontoDistribuicao",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosDistribuicao_Enderecos_IdEndereco",
                table: "PontosDistribuicao");

            migrationBuilder.DropForeignKey(
                name: "FK_PontosDistribuicao_Usuarios_IdUsuario",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_PontosDistribuicao_IdEndereco",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_PontosDistribuicao_IdUsuario",
                table: "PontosDistribuicao");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_IdItem",
                table: "Estoques");

            migrationBuilder.DropIndex(
                name: "IX_Estoques_IdPontoDistribuicao",
                table: "Estoques");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuarios",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCompleto",
                table: "Usuarios",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Usuarios",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "PontosDistribuicao",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "PontosDistribuicao",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "PontosDistribuicao",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Itens",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Itens",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Estoques",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PontoDistribuicaoId",
                table: "Estoques",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(60)",
                oldMaxLength: 60);

            migrationBuilder.CreateIndex(
                name: "IX_PontosDistribuicao_EnderecoId",
                table: "PontosDistribuicao",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosDistribuicao_UsuarioId",
                table: "PontosDistribuicao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ItemId",
                table: "Estoques",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_PontoDistribuicaoId",
                table: "Estoques",
                column: "PontoDistribuicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Itens_ItemId",
                table: "Estoques",
                column: "ItemId",
                principalTable: "Itens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_PontosDistribuicao_PontoDistribuicaoId",
                table: "Estoques",
                column: "PontoDistribuicaoId",
                principalTable: "PontosDistribuicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDistribuicao_Enderecos_EnderecoId",
                table: "PontosDistribuicao",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDistribuicao_Usuarios_UsuarioId",
                table: "PontosDistribuicao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
