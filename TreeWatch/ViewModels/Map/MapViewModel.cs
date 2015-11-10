﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System;

namespace TreeWatch
{
	public class MapViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		ObservableCollection<Field> fields;
		String searchText = String.Empty;
		Command searchCommand;
		Field selectedField;

		public MapViewModel ()
		{
			SelectFieldCommand = new Command<Field> ((field) => {
				if (typeof(Field) == field.GetType ()) {
					selectedField = field;
				}
			});

			fields = new ObservableCollection<Field> ();

			SetUpMockData ();
		}

		void SetUpMockData ()
		{
			Fields.Add (new Field ("Ajax"));
			Fields.Add (new Field ("PSV"));
			Fields.Add (new Field ("Roda jc"));
			Fields.Add (new Field ("VVV"));
			Fields.Add (new Field ("Hertog Jan"));
			Fields.Add (new Field ("Twente"));

			var testfield = new Field ("TestField");
			var fieldcords = new List<PositionModel> ();

			fieldcords.Add (new PositionModel (51.39202, 6.04745));
			fieldcords.Add (new PositionModel (51.39202, 6.05116));
			fieldcords.Add (new PositionModel (51.38972, 6.05116));
			fieldcords.Add (new PositionModel (51.38972, 6.04745));
			testfield.BoundingCordinates = fieldcords;

			var row = new List<Block> ();
			row.Add (new Block (new PositionModel (51.39082462477471, 6.050752777777778), new PositionModel (51.3904837408623, 6.047676310228867), TreeType.APPLE));
			testfield.Rows = row;
			Fields.Add (testfield);
		}

		public ICommand SelectFieldCommand { private set; get; }

		public string SearchText {
			get { return searchText; }
			set { 
				if (searchText != value) { 
					searchText = value ?? string.Empty;
					OnPropertyChanged ("SearchText");
					if (SearchCommand.CanExecute (null)) {
						SearchCommand.Execute (null);
					}
				}
			}
		}

		public ObservableCollection<Field> FilteredFields {
			get {
				var theCollection = new ObservableCollection<Field> ();

				if (Fields != null) {
					List<Field> entities = Fields.Where (x => x.Name.ToLower ().Contains (searchText.ToLower ())).ToList (); 
					if (entities != null && entities.Any ()) {
						theCollection = new ObservableCollection<Field> (entities);
					}
				}
				return theCollection;
			}
		}

		public ICommand SearchCommand {
			get {
				searchCommand = searchCommand ?? new Command (DoSearchCommand, CanExecuteSearchCommand);
				return searchCommand;
			}
		}

		void DoSearchCommand ()
		{
			// Refresh the list, which will automatically apply the search text
			OnPropertyChanged ("FilteredFields");
		}

		static bool CanExecuteSearchCommand ()
		{
			return true;
		}

		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler (this, new PropertyChangedEventArgs (propertyName));

		}

		public Position getCurrentDevicePosition ()
		{
			// Todo: make this not static
			const double latitude = 51.39202;
			const double longitude = 6.04745;

			return new Position (latitude, longitude);
		}

		public ObservableCollection<Field> Fields {
			get { return fields; }
			private set { this.fields = value; }
		}
			
	}
}

