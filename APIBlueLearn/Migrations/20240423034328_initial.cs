using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBlueLearn.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    IdCampo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamano = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.IdCampo);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionMonitoreo",
                columns: table => new
                {
                    IdDescripcionMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionMonitoreo", x => x.IdDescripcionMonitoreo);
                });

            migrationBuilder.CreateTable(
                name: "EstadoCultivo",
                columns: table => new
                {
                    IdEstadoCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCultivo", x => x.IdEstadoCultivo);
                });

            migrationBuilder.CreateTable(
                name: "EstadoOperacion",
                columns: table => new
                {
                    IdEstadoOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOperacion", x => x.IdEstadoOperacion);
                });

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    IdEtapa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.IdEtapa);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    IdJugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntaje = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.IdJugador);
                });

            migrationBuilder.CreateTable(
                name: "Logro",
                columns: table => new
                {
                    IdLogro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logro", x => x.IdLogro);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    IdTemporada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temporada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.IdTemporada);
                });

            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    IdCultivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPlantacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoCultivo = table.Column<int>(type: "int", nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CamposIdCampo = table.Column<int>(type: "int", nullable: true),
                    EstadoCultivoIdEstadoCultivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.IdCultivo);
                    table.ForeignKey(
                        name: "FK_Cultivos_Campos_CamposIdCampo",
                        column: x => x.CamposIdCampo,
                        principalTable: "Campos",
                        principalColumn: "IdCampo");
                    table.ForeignKey(
                        name: "FK_Cultivos_EstadoCultivo_EstadoCultivoIdEstadoCultivo",
                        column: x => x.EstadoCultivoIdEstadoCultivo,
                        principalTable: "EstadoCultivo",
                        principalColumn: "IdEstadoCultivo");
                });

            migrationBuilder.CreateTable(
                name: "Agricultores",
                columns: table => new
                {
                    IdAgricultor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    JugadorIdJugador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agricultores", x => x.IdAgricultor);
                    table.ForeignKey(
                        name: "FK_Agricultores_Jugador_JugadorIdJugador",
                        column: x => x.JugadorIdJugador,
                        principalTable: "Jugador",
                        principalColumn: "IdJugador");
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePartida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdJugador = table.Column<int>(type: "int", nullable: false),
                    IdLogro = table.Column<int>(type: "int", nullable: false),
                    PuntajePartida = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    JugadorIdJugador = table.Column<int>(type: "int", nullable: true),
                    LogroIdLogro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
                    table.ForeignKey(
                        name: "FK_Partida_Jugador_JugadorIdJugador",
                        column: x => x.JugadorIdJugador,
                        principalTable: "Jugador",
                        principalColumn: "IdJugador");
                    table.ForeignKey(
                        name: "FK_Partida_Logro_LogroIdLogro",
                        column: x => x.LogroIdLogro,
                        principalTable: "Logro",
                        principalColumn: "IdLogro");
                });

            migrationBuilder.CreateTable(
                name: "Cosechas",
                columns: table => new
                {
                    IdCosechas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCosecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadRecogida = table.Column<int>(type: "int", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdTemporada = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true),
                    TemporadasIdTemporada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cosechas", x => x.IdCosechas);
                    table.ForeignKey(
                        name: "FK_Cosechas_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                    table.ForeignKey(
                        name: "FK_Cosechas_Temporadas_TemporadasIdTemporada",
                        column: x => x.TemporadasIdTemporada,
                        principalTable: "Temporadas",
                        principalColumn: "IdTemporada");
                });

            migrationBuilder.CreateTable(
                name: "Monitoreo",
                columns: table => new
                {
                    IdMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMonitoreo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    IdDescripcionMonitoreo = table.Column<int>(type: "int", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true),
                    DescripcionMonitoreoIdDescripcionMonitoreo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoreo", x => x.IdMonitoreo);
                    table.ForeignKey(
                        name: "FK_Monitoreo_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                    table.ForeignKey(
                        name: "FK_Monitoreo_DescripcionMonitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                        column: x => x.DescripcionMonitoreoIdDescripcionMonitoreo,
                        principalTable: "DescripcionMonitoreo",
                        principalColumn: "IdDescripcionMonitoreo");
                });

            migrationBuilder.CreateTable(
                name: "EtapaAprendizaje",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgricultor = table.Column<int>(type: "int", nullable: false),
                    IdEtapa = table.Column<int>(type: "int", nullable: false),
                    FechaInit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    AgricultoresIdAgricultor = table.Column<int>(type: "int", nullable: true),
                    EtapaIdEtapa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtapaAprendizaje", x => x.IdEstado);
                    table.ForeignKey(
                        name: "FK_EtapaAprendizaje_Agricultores_AgricultoresIdAgricultor",
                        column: x => x.AgricultoresIdAgricultor,
                        principalTable: "Agricultores",
                        principalColumn: "IdAgricultor");
                    table.ForeignKey(
                        name: "FK_EtapaAprendizaje_Etapa_EtapaIdEtapa",
                        column: x => x.EtapaIdEtapa,
                        principalTable: "Etapa",
                        principalColumn: "IdEtapa");
                });

            migrationBuilder.CreateTable(
                name: "OpeCultivos",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstadoOperacion = table.Column<int>(type: "int", nullable: false),
                    FechaOperacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCultivo = table.Column<int>(type: "int", nullable: false),
                    IdAgricultor = table.Column<int>(type: "int", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    CultivosIdCultivo = table.Column<int>(type: "int", nullable: true),
                    EstadoOperacionIdEstadoOperacion = table.Column<int>(type: "int", nullable: true),
                    AgricultoresIdAgricultor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeCultivos", x => x.IdOperacion);
                    table.ForeignKey(
                        name: "FK_OpeCultivos_Agricultores_AgricultoresIdAgricultor",
                        column: x => x.AgricultoresIdAgricultor,
                        principalTable: "Agricultores",
                        principalColumn: "IdAgricultor");
                    table.ForeignKey(
                        name: "FK_OpeCultivos_Cultivos_CultivosIdCultivo",
                        column: x => x.CultivosIdCultivo,
                        principalTable: "Cultivos",
                        principalColumn: "IdCultivo");
                    table.ForeignKey(
                        name: "FK_OpeCultivos_EstadoOperacion_EstadoOperacionIdEstadoOperacion",
                        column: x => x.EstadoOperacionIdEstadoOperacion,
                        principalTable: "EstadoOperacion",
                        principalColumn: "IdEstadoOperacion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agricultores_JugadorIdJugador",
                table: "Agricultores",
                column: "JugadorIdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Cosechas_CultivosIdCultivo",
                table: "Cosechas",
                column: "CultivosIdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Cosechas_TemporadasIdTemporada",
                table: "Cosechas",
                column: "TemporadasIdTemporada");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_CamposIdCampo",
                table: "Cultivos",
                column: "CamposIdCampo");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivos_EstadoCultivoIdEstadoCultivo",
                table: "Cultivos",
                column: "EstadoCultivoIdEstadoCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaAprendizaje_AgricultoresIdAgricultor",
                table: "EtapaAprendizaje",
                column: "AgricultoresIdAgricultor");

            migrationBuilder.CreateIndex(
                name: "IX_EtapaAprendizaje_EtapaIdEtapa",
                table: "EtapaAprendizaje",
                column: "EtapaIdEtapa");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreo_CultivosIdCultivo",
                table: "Monitoreo",
                column: "CultivosIdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreo_DescripcionMonitoreoIdDescripcionMonitoreo",
                table: "Monitoreo",
                column: "DescripcionMonitoreoIdDescripcionMonitoreo");

            migrationBuilder.CreateIndex(
                name: "IX_OpeCultivos_AgricultoresIdAgricultor",
                table: "OpeCultivos",
                column: "AgricultoresIdAgricultor");

            migrationBuilder.CreateIndex(
                name: "IX_OpeCultivos_CultivosIdCultivo",
                table: "OpeCultivos",
                column: "CultivosIdCultivo");

            migrationBuilder.CreateIndex(
                name: "IX_OpeCultivos_EstadoOperacionIdEstadoOperacion",
                table: "OpeCultivos",
                column: "EstadoOperacionIdEstadoOperacion");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_JugadorIdJugador",
                table: "Partida",
                column: "JugadorIdJugador");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_LogroIdLogro",
                table: "Partida",
                column: "LogroIdLogro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cosechas");

            migrationBuilder.DropTable(
                name: "EtapaAprendizaje");

            migrationBuilder.DropTable(
                name: "Monitoreo");

            migrationBuilder.DropTable(
                name: "OpeCultivos");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Temporadas");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "DescripcionMonitoreo");

            migrationBuilder.DropTable(
                name: "Agricultores");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "EstadoOperacion");

            migrationBuilder.DropTable(
                name: "Logro");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "EstadoCultivo");
        }
    }
}
