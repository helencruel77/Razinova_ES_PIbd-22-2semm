﻿namespace LawFirmView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бланкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пакетыДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокБланковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.бланкиПоПакетамДокументовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(907, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.бланкиToolStripMenuItem,
            this.пакетыДокументовToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // бланкиToolStripMenuItem
            // 
            this.бланкиToolStripMenuItem.Name = "бланкиToolStripMenuItem";
            this.бланкиToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.бланкиToolStripMenuItem.Text = "Бланки";
            this.бланкиToolStripMenuItem.Click += new System.EventHandler(this.бланкиToolStripMenuItem_Click);
            // 
            // пакетыДокументовToolStripMenuItem
            // 
            this.пакетыДокументовToolStripMenuItem.Name = "пакетыДокументовToolStripMenuItem";
            this.пакетыДокументовToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.пакетыДокументовToolStripMenuItem.Text = "Пакеты документов";
            this.пакетыДокументовToolStripMenuItem.Click += new System.EventHandler(this.пакетыДокументовToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокБланковToolStripMenuItem,
            this.бланкиПоПакетамДокументовToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокБланковToolStripMenuItem
            // 
            this.списокБланковToolStripMenuItem.Name = "списокБланковToolStripMenuItem";
            this.списокБланковToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.списокБланковToolStripMenuItem.Text = "Список бланков";
            this.списокБланковToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // бланкиПоПакетамДокументовToolStripMenuItem
            // 
            this.бланкиПоПакетамДокументовToolStripMenuItem.Name = "бланкиПоПакетамДокументовToolStripMenuItem";
            this.бланкиПоПакетамДокументовToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.бланкиПоПакетамДокументовToolStripMenuItem.Text = "Бланки по пакетам документов";
            this.бланкиПоПакетамДокументовToolStripMenuItem.Click += new System.EventHandler(this.бланкиПоПакетамДокументовToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(722, 411);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(752, 46);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(123, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonTakeInWork
            // 
            this.buttonTakeInWork.Location = new System.Drawing.Point(753, 124);
            this.buttonTakeInWork.Name = "buttonTakeInWork";
            this.buttonTakeInWork.Size = new System.Drawing.Size(123, 38);
            this.buttonTakeInWork.TabIndex = 3;
            this.buttonTakeInWork.Text = "Отдать на выполнение";
            this.buttonTakeInWork.UseVisualStyleBackColor = true;
            this.buttonTakeInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(753, 217);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(124, 23);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(753, 309);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(125, 23);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(753, 392);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(123, 23);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 450);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бланкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пакетыДокументовToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокБланковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem бланкиПоПакетамДокументовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}