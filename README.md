Questo programma è un'applicazione WPF che visualizza due griglie: una per elencare le persone e l'altra per gli elenchi dei contatti. L'utente può caricare i dati da due file CSV: "Persone.csv" e "Contatti.csv". Il programma legge i file CSV, crea oggetti Persona e Contatto corrispondenti ai dati letti e li aggiunge alle rispettive liste (Persone e Contatti). Queste liste sono utilizzate come origini dati per le due griglie (dgPersone e dgContatti).

Quando l'utente seleziona una persona nella griglia delle persone (dgPersone), il gestore degli eventi dgDati_SelectionChanged viene attivato. Questo metodo recupera la persona selezionata e filtra i contatti corrispondenti a quella persona. I contatti filtrati vengono quindi visualizzati nella griglia dei contatti (dgContatti).

#Codice:

     private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
Il programma fornisce anche una barra di stato (statusbar) che mostra informazioni sull'operazione corrente, come il numero di righe lette o il contatto selezionato.

#Codice:

 statusbar.Text = $"Ho letto {Persone.Count} righe";
In sintesi, il programma consente all'utente di visualizzare e filtrare i contatti in base alle persone selezionate, utilizzando due griglie e due file CSV come sorgenti dati.
