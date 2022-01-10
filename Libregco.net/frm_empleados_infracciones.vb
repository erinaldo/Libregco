Public Class frm_empleados_infracciones
    Private Sub frm_empleados_infracciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = CheckWindowState()
        SetToolTipMessages()
    End Sub

    Private Sub SetToolTipMessages()
        With ToolTip1
            .SetToolTip(chk1, "Por haber el trabajador inducido a error al empleador pretendiendo tener condiciones o conocimientos indispensables que no posee, o presentándole referencias o certificados personales cuya falsedad se comprueba luego.")
            .SetToolTip(chk2, "Por ejecutar el trabajo en forma que demuestre su incapacidad e ineficiencia. Esta causa deja de tener efecto a partir de los tres meses de prestar servicios el trabajador.")
            .SetToolTip(chk3, "Por incurrir el trabajador durante sus labores en faltas de probidad o de honradez, en actos o intentos de violencias, injurias o malos tratamientos contra el empleador o los parientes de éste bajo su dependencia.")
            .SetToolTip(chk4, "Por cometer el trabajador, contra alguno de sus compañeros, cualesquiera de los actos enumerados en el apartado anterior, si ello altera el orden del lugar en que trabaja.")
            .SetToolTip(chk5, "Por cometer el trabajador, fuera de servicio, contra el empleador o los parientes que dependen de él, o contra los jefes de la empresa, algunos de los actos a que se refiere el ordinal 3o. del presente artículo.")
            .SetToolTip(chk6, "Por ocasionar el trabajador, intencionalmente, perjuicios materiales, durante el desempeño de las labores o con motivo de éstas, en los edificios, obras, maquinarias, herramientas, materias primas, productos y demás objetos relacionados con el trabajo.")
            .SetToolTip(chk7, "Por ocasionar el trabajador los perjuicios graves, mencionados en el ordinal anterior, sin intención, pero con negligencia o imprudencia de tal naturaleza que sean la causa del perjuicio.")

            .SetToolTip(chk8, "Por cometer el trabajador actos deshonestos en el taller, establecimiento o lugar de trabajo.")
            .SetToolTip(chk9, "Por revelar el trabajador los secretos de fabricación o dar a conocer asuntos de carácter reservado en perjuicio de la empresa.")
            .SetToolTip(chk10, "Por comprometer el trabajador, por imprudencia o descuido inexcusables, la seguridad del taller, oficina u otro centro de  la empresa o de personas que allí se encuentren.")
            .SetToolTip(chk11, "Por inasistencia del trabajador a sus labores durante dos días consecutivos o dos días en un mismo mes sin permiso del empleador o de quien lo represente, o sin notificar la causa justa que tuvo para ello en el plazo prescrito por el artículo 58.")
            .SetToolTip(chk12, "Por ausencia, sin notificación de la causa justificada, del trabajador que tenga a su cargo alguna faena o máquina cuya inactividad o paralización implique necesariamente una perturbación para la empresa.")
            .SetToolTip(chk13, "Por salir el trabajador durante las horas de trabajo sin permiso del empleador o de quien lo represente y sin haberse manifestado a dicho empleador o a su representante, con anterioridad, la causa justificada que tuviere para abandonar el trabajo.")
            .SetToolTip(chk14, "Por desobedecer el trabajador al empleador o a sus representantes, siempre que se trate del servicio contratado.")

            .SetToolTip(chk15, "Por negarse el trabajador a adoptar las medidas preventivas o a seguir los procedimientos indicados por la ley, las autoridades competentes o los empleadores, para evitar accidentes o enfermedades.")
            .SetToolTip(chk16, "Por violar el trabajador cualesquiera de las prohibiciones previstas en los ordinales 1o, 2o, 5o y 6o. del artículo 45.")
            .SetToolTip(chk17, "Por violar el trabajador cualesquiera de las prohibiciones previstas en los ordinales 3o. y 4o., del artículo 45 después que el Departamento de Trabajo o la autoridad local que ejerza sus funciones lo haya amonestado por la misma falta a requerimiento del empleador.")
            .SetToolTip(chk18, "Por haber sido condenado el trabajador a una pena privativa de libertad por sentencia irrevocable.")
            .SetToolTip(chk19, "Por falta de dedicación a las labores para las cuales ha sido contratado o por cualquier otra falta grave a las obligaciones que el contrato imponga al trabajador.")


        End With
    End Sub
End Class