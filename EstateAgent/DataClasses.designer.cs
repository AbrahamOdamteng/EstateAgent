﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstateAgent
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="dgcodetest_AO")]
	public partial class EstateAgentDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLandlord(Landlord instance);
    partial void UpdateLandlord(Landlord instance);
    partial void DeleteLandlord(Landlord instance);
    partial void InsertProperty(Property instance);
    partial void UpdateProperty(Property instance);
    partial void DeleteProperty(Property instance);
    #endregion
		
		public EstateAgentDataContext() : 
				base(global::EstateAgent.Properties.Settings.Default.dgcodetest_AOConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public EstateAgentDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstateAgentDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstateAgentDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public EstateAgentDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Landlord> Landlords
		{
			get
			{
				return this.GetTable<Landlord>();
			}
		}
		
		public System.Data.Linq.Table<Property> Properties
		{
			get
			{
				return this.GetTable<Property>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Landlords")]
	public partial class Landlord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LandlordId;
		
		private string _Forename;
		
		private string _Surname;
		
		private string _Phone;
		
		private string _Email;
		
		private EntityRef<Landlord> _Landlord2;
		
		private EntitySet<Property> _Properties;
		
		private EntityRef<Landlord> _Landlord1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLandlordIdChanging(int value);
    partial void OnLandlordIdChanged();
    partial void OnForenameChanging(string value);
    partial void OnForenameChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Landlord()
		{
			this._Landlord2 = default(EntityRef<Landlord>);
			this._Properties = new EntitySet<Property>(new Action<Property>(this.attach_Properties), new Action<Property>(this.detach_Properties));
			this._Landlord1 = default(EntityRef<Landlord>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LandlordId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int LandlordId
		{
			get
			{
				return this._LandlordId;
			}
			set
			{
				if ((this._LandlordId != value))
				{
					if (this._Landlord1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLandlordIdChanging(value);
					this.SendPropertyChanging();
					this._LandlordId = value;
					this.SendPropertyChanged("LandlordId");
					this.OnLandlordIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Forename", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Forename
		{
			get
			{
				return this._Forename;
			}
			set
			{
				if ((this._Forename != value))
				{
					this.OnForenameChanging(value);
					this.SendPropertyChanging();
					this._Forename = value;
					this.SendPropertyChanged("Forename");
					this.OnForenameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(150) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Landlord_Landlord", Storage="_Landlord2", ThisKey="LandlordId", OtherKey="LandlordId", IsUnique=true, IsForeignKey=false)]
		public Landlord Landlord2
		{
			get
			{
				return this._Landlord2.Entity;
			}
			set
			{
				Landlord previousValue = this._Landlord2.Entity;
				if (((previousValue != value) 
							|| (this._Landlord2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Landlord2.Entity = null;
						previousValue.Landlord1 = null;
					}
					this._Landlord2.Entity = value;
					if ((value != null))
					{
						value.Landlord1 = this;
					}
					this.SendPropertyChanged("Landlord2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Landlord_Property", Storage="_Properties", ThisKey="LandlordId", OtherKey="LandlordId")]
		public EntitySet<Property> Properties
		{
			get
			{
				return this._Properties;
			}
			set
			{
				this._Properties.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Landlord_Landlord", Storage="_Landlord1", ThisKey="LandlordId", OtherKey="LandlordId", IsForeignKey=true)]
		public Landlord Landlord1
		{
			get
			{
				return this._Landlord1.Entity;
			}
			set
			{
				Landlord previousValue = this._Landlord1.Entity;
				if (((previousValue != value) 
							|| (this._Landlord1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Landlord1.Entity = null;
						previousValue.Landlord2 = null;
					}
					this._Landlord1.Entity = value;
					if ((value != null))
					{
						value.Landlord2 = this;
						this._LandlordId = value.LandlordId;
					}
					else
					{
						this._LandlordId = default(int);
					}
					this.SendPropertyChanged("Landlord1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Properties(Property entity)
		{
			this.SendPropertyChanging();
			entity.Landlord = this;
		}
		
		private void detach_Properties(Property entity)
		{
			this.SendPropertyChanging();
			entity.Landlord = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Properties")]
	public partial class Property : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PropertyId;
		
		private string _Housenumber;
		
		private string _Street;
		
		private string _Town;
		
		private string _PostCode;
		
		private System.DateTime _AvailableFrom;
		
		private string _Status;
		
		private int _LandlordId;
		
		private EntityRef<Landlord> _Landlord;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPropertyIdChanging(int value);
    partial void OnPropertyIdChanged();
    partial void OnHousenumberChanging(string value);
    partial void OnHousenumberChanged();
    partial void OnStreetChanging(string value);
    partial void OnStreetChanged();
    partial void OnTownChanging(string value);
    partial void OnTownChanged();
    partial void OnPostCodeChanging(string value);
    partial void OnPostCodeChanged();
    partial void OnAvailableFromChanging(System.DateTime value);
    partial void OnAvailableFromChanged();
    partial void OnStatusChanging(string value);
    partial void OnStatusChanged();
    partial void OnLandlordIdChanging(int value);
    partial void OnLandlordIdChanged();
    #endregion
		
		public Property()
		{
			this._Landlord = default(EntityRef<Landlord>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PropertyId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PropertyId
		{
			get
			{
				return this._PropertyId;
			}
			set
			{
				if ((this._PropertyId != value))
				{
					this.OnPropertyIdChanging(value);
					this.SendPropertyChanging();
					this._PropertyId = value;
					this.SendPropertyChanged("PropertyId");
					this.OnPropertyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Housenumber", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Housenumber
		{
			get
			{
				return this._Housenumber;
			}
			set
			{
				if ((this._Housenumber != value))
				{
					this.OnHousenumberChanging(value);
					this.SendPropertyChanging();
					this._Housenumber = value;
					this.SendPropertyChanged("Housenumber");
					this.OnHousenumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Street", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Street
		{
			get
			{
				return this._Street;
			}
			set
			{
				if ((this._Street != value))
				{
					this.OnStreetChanging(value);
					this.SendPropertyChanging();
					this._Street = value;
					this.SendPropertyChanged("Street");
					this.OnStreetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Town", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Town
		{
			get
			{
				return this._Town;
			}
			set
			{
				if ((this._Town != value))
				{
					this.OnTownChanging(value);
					this.SendPropertyChanging();
					this._Town = value;
					this.SendPropertyChanged("Town");
					this.OnTownChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostCode", DbType="VarChar(12) NOT NULL", CanBeNull=false)]
		public string PostCode
		{
			get
			{
				return this._PostCode;
			}
			set
			{
				if ((this._PostCode != value))
				{
					this.OnPostCodeChanging(value);
					this.SendPropertyChanging();
					this._PostCode = value;
					this.SendPropertyChanged("PostCode");
					this.OnPostCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AvailableFrom", DbType="DateTime NOT NULL")]
		public System.DateTime AvailableFrom
		{
			get
			{
				return this._AvailableFrom;
			}
			set
			{
				if ((this._AvailableFrom != value))
				{
					this.OnAvailableFromChanging(value);
					this.SendPropertyChanging();
					this._AvailableFrom = value;
					this.SendPropertyChanged("AvailableFrom");
					this.OnAvailableFromChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LandlordId", DbType="Int NOT NULL")]
		public int LandlordId
		{
			get
			{
				return this._LandlordId;
			}
			set
			{
				if ((this._LandlordId != value))
				{
					if (this._Landlord.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLandlordIdChanging(value);
					this.SendPropertyChanging();
					this._LandlordId = value;
					this.SendPropertyChanged("LandlordId");
					this.OnLandlordIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Landlord_Property", Storage="_Landlord", ThisKey="LandlordId", OtherKey="LandlordId", IsForeignKey=true)]
		public Landlord Landlord
		{
			get
			{
				return this._Landlord.Entity;
			}
			set
			{
				Landlord previousValue = this._Landlord.Entity;
				if (((previousValue != value) 
							|| (this._Landlord.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Landlord.Entity = null;
						previousValue.Properties.Remove(this);
					}
					this._Landlord.Entity = value;
					if ((value != null))
					{
						value.Properties.Add(this);
						this._LandlordId = value.LandlordId;
					}
					else
					{
						this._LandlordId = default(int);
					}
					this.SendPropertyChanged("Landlord");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591