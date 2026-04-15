using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlow.Web.Migrations
{
    /// <inheritdoc />
    public partial class RenameDataToDataMovimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Lancamentos",
                newName: "DataMovimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataMovimento",
                table: "Lancamentos",
                newName: "Data");
        }
    }
}
