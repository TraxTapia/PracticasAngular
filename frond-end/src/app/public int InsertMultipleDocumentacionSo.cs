  public int InsertMultipleDocumentacionSoporteEstatus(List<UniversalModeloNegocio.Documentacion.DocumentacionSoporteEstatus> request)
        {
            int filasAfectadas = 0;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                conn.Open();
                foreach (var i in request.ToList())
                {
                    i.UsuAlta = UserId;
                    i.UsuCambio = UserId;
                    if (i.Id == 0)
                    {
                        string Query = "INSERT INTO dbo.DocumentacionSoporteEstatus(SoporteId, EstatusId, DocumentacionSoporteId, MotivoRechazoId, MotivoRechazo, Observaciones, Activo, UsuAlta)" +
                        " VALUES( " + i.SoporteId + ", " + i.EstatusId + ", " + i.DocumentacionSoporteId + ", " + i.MotivoRechazoId + ", '" + i.MotivoRechazo + "', '" + i.Observaciones + "', '" + i.Activo + "', '" + i.UsuAlta + "')";
                        SqlCommand cmd = new SqlCommand(Query, conn)
                        {
                            CommandType = CommandType.Text
                        };

                        cmd.CommandTimeout = 60 * 5;
                        filasAfectadas = cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        var exist = ObtenerRegistros(i.SoporteId, i.DocumentacionSoporteId);
                        if (exist != null)
                        {
                            string observacion = string.IsNullOrEmpty(i.Observaciones) ? string.Empty : i.Observaciones;
                            string motivoRechazo = ObtenerMotivoRechazo(i.MotivoRechazoId, 1);
                            string queryUpdate = "UPDATE p " +
                                " SET p.EstatusId = " + i.EstatusId + ", p.MotivoRechazoId = " + i.MotivoRechazoId + ", " +
                                " p.MotivoRechazo = '" + motivoRechazo + "', p.Observaciones = '" + observacion + "', p.Activo = '" + i.Activo + "', p.UsuCambio = '" + i.UsuCambio + "' " +
                                " FROM dbo.DocumentacionSoporteEstatus p" +
                                " WHERE p.Id = " + i.Id + "";
                            SqlCommand cmd = new SqlCommand(queryUpdate, conn)
                            {
                                CommandType = CommandType.Text
                            };

                            cmd.CommandTimeout = 60 * 5;
                            filasAfectadas = cmd.ExecuteNonQuery();

                        }
                    }
                }
                conn.Close();
                conn.Dispose();
                if (filasAfectadas == 0)
                {
                    filasAfectadas = 0;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new ApplicationException(ex.Message);
            }
            return filasAfectadas;
        }