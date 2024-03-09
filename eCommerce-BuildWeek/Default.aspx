<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="eCommerce_BuildWeek._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="container">

            <h2 class="text-center mb-2">BlackMarket Store, ti dà il <span class="orange-span">benvenuto</span></h2>
            <p class="text-center mb-4 fs-5">L'e-commerce italiano dedicato alla vendita di articoli da softair</p>


            <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="3" aria-label="Slide 4"></button>
                    <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="4" aria-label="Slide 5"></button>
                </div>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="./Content/assets/carosello0.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5 class="orange-span fs-2 headingCarousel">UNITA' E TATTICA</h5>
                            <p class="parCarousel">Esplora il nostro arsenale per squadre d'élite. Tutto ciò di cui avete bisogno per dominare in ogni scenario.</p>
                        </div>
                    </div>


                    <div class="carousel-item">
                        <img src="./Content/assets/carosello1.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5 class="orange-span fs-2 headingCarousel">OGNI COLPO CONTA</h5>
                            <p class="parCarousel">La nostra selezione di sistemi di mira ti aiuterà a tenere il bersaglio sempre a fuoco. La tua prossima missione inizia qui.</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="./Content/assets/carosello2.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5 class="orange-span fs-2 headingCarousel">PREDATORE OMBRA</h5>
                            <p class="parCarousel">L'elemento sorpresa sarà la tua arma più potente. Diventa invisibile, diventa invincibile.</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="./Content/assets/carosello3.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5 class="orange-span fs-2 headingCarousel">PRONTI, PUNTARE, FUOCO</h5>
                            <p class="parCarousel">Affina le tue capacità con strumenti progettati per la vittoria. Per tiratori che esigono solo il meglio.</p>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <img src="./Content/assets/carosello6.png" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5 class="orange-span fs-2 headingCarousel">VETERANI DEL CAMPO</h5>
                            <p class="parCarousel">Attrezzature testate in campo per superare le prove più dure. Oltre il tempo, oltre i limiti.</p>
                        </div>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>

            <h2 class="text-center my-5 fs-3">Le nostre <span class="orange-span">TOP CATEGORIES</span></h2>
            <div class="row">
                <div class="col-4 text-center">
                    <a runat="server" href="~/Articoli.aspx?Categoria=Fucile%20d'assalto">
                        <img src="./Content/assets/cat-assault.png" class="top-category  rounded-2" alt="assault-category" width="150">
                    </a>
                </div>

                <div class="col-4 text-center">
                    <a runat="server" href="~/Articoli.aspx?Categoria=mitraglietta">
                        <img src="./Content/assets/cat-smg.png" class="top-category  rounded-2" alt="smg-category" width="150">
                    </a>
                </div>



                <div class="col-4 text-center">
                    <a runat="server" href="~/Articoli.aspx?Categoria=pistola">
                        <img src="./Content/assets/cat-gun.png" class="top-category rounded-2" alt="pistol-category" width="150">
                    </a>
                </div>
            </div>


            <h2 class="text-center my-5 fs-3">TUTTI GLI <span class="orange-span">ARTICOLI</span></h2>

            <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 row-cols-xl-4">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class="col gy-3">
                            <div class="card mx-2 my-2 bg-transparent border-0 text-white overflow-hidden shadow">

                                <div class="d-flex  align-items-center mx-auto">
                                    <h5 class="title-up card-title m-0 fs-2 fw-bold mt-3"><%# Eval("Nome") %></h5>
                                </div>

                                <div class="position-relative">
                                    <img src='<%# Eval("Immagine") %>' class="px-3 card-img-top img-fluid" style="max-height: 250px; object-fit: contain" alt='<%# Eval("Nome") %>'>
                                    <span class="custom-span fs-5 bg-opacity-75 shadow rounded-0 badge w-100  bg-opacity-75"><%# Eval("Prezzo", "{0:c2}") %></span>
                                </div>

                                <a href="<%# "Dettagli.aspx?IdProdotto=" + Eval("idProdotto") %>" class="text-decoration-none rounded-0 w-100 text-white btn btn2i fw-bolder text-white">Dettagli
                                </a>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

    </main>

</asp:Content>
