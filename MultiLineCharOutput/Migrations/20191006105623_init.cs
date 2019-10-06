using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiLineCharOutput.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusInd = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    BankAcctNbr = table.Column<string>(nullable: true),
                    BankAcctTransit = table.Column<string>(nullable: true),
                    RcrsTransitRoute = table.Column<string>(nullable: true),
                    RcrsAccountNum = table.Column<string>(nullable: true),
                    CompanyCode = table.Column<string>(nullable: true),
                    DiscountAmt = table.Column<decimal>(nullable: false),
                    EftAdviceNum = table.Column<string>(nullable: true),
                    EftAmt = table.Column<decimal>(nullable: false),
                    CheckNumber = table.Column<string>(nullable: true),
                    CheckDate = table.Column<string>(nullable: true),
                    CheckAmt = table.Column<decimal>(nullable: false),
                    EftTraceNum = table.Column<string>(nullable: true),
                    EntryDate = table.Column<string>(nullable: true),
                    InvoiceAmt = table.Column<decimal>(nullable: false),
                    InvoiceDate = table.Column<string>(nullable: true),
                    NetInvoiceAmt = table.Column<decimal>(nullable: false),
                    PayDate = table.Column<string>(nullable: true),
                    PaymentId = table.Column<string>(nullable: true),
                    PaymentMode = table.Column<string>(nullable: true),
                    TinType = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    VendorName1 = table.Column<string>(nullable: true),
                    GenericName2 = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    RemitAddress1 = table.Column<string>(nullable: true),
                    RemitAddress2 = table.Column<string>(nullable: true),
                    RemitAddress3 = table.Column<string>(nullable: true),
                    RemitCity = table.Column<string>(nullable: true),
                    RemitCountryCode = table.Column<string>(nullable: true),
                    RemitState = table.Column<string>(nullable: true),
                    RemitZipcode = table.Column<string>(nullable: true),
                    EffectiveDate = table.Column<string>(nullable: true),
                    ReferenceData = table.Column<string>(nullable: true),
                    SourceCode = table.Column<string>(nullable: true),
                    TranHdrDesc = table.Column<string>(nullable: true),
                    RecvPartAcctType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APs");
        }
    }
}
